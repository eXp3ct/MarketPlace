using Ksu.Market.Data.Interfaces;
using Ksu.Market.Domain.Models;
using Ksu.Market.Domain.Results;
using MassTransit.SagaStateMachine;
using Microsoft.AspNetCore.Mvc;

namespace Ksu.Market.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<ProductImage> _images;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public ImagesController(IConfiguration configuration, IRepository<ProductImage> images)
        {
            _configuration = configuration;
            _images = images;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("{productId}")]
        public async Task<IActionResult> UploadImage(IFormFile image,[FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            try
            {
                if (!Directory.Exists("img"))
                {
                    Directory.CreateDirectory("img");
                }

                if (image.Length > 0)
                {
                    var basePath = _configuration.GetSection("ImageBasePath").Value; // путь для сохранения изображений
                    var id = Guid.NewGuid();
                    var fullName = image.FileName.Split('.');
                    var extenstion = fullName.LastOrDefault()!;
                    if (string.IsNullOrEmpty(basePath))
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }

                    var productImage = new ProductImage
                    {
                        Id = id,
                        DateUploaded = DateTime.UtcNow,
                        ExtensionName = extenstion,
                        ProductId = productId,
                        FileName = fullName.FirstOrDefault(),
                        FilePath = $"{id}.{extenstion}"
                    };

                    await _images.Create(productImage, cancellationToken);
                    await _images.SaveChangesAsync(cancellationToken);

                    var filePath = Path.Combine(basePath, productImage.FilePath);

                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await image.CopyToAsync(fileStream, cancellationToken);

                    return Ok(new OperationResult(productImage, true));
                }

                return BadRequest(new OperationResult(null, false));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImages(Guid productId, CancellationToken cancellationToken)
        {
            var images = await _images.GetListAsync(1, 1000, cancellationToken);
            images = images.Where(x => x.ProductId == productId).ToList();

            return Ok(new OperationResult(images, true));
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetProductImage([FromRoute] Guid imageId, CancellationToken cancellationToken)
        {
            var image = await _images.GetByIdAsync(imageId, cancellationToken);
            if(image == null)
            {
                return NotFound(new OperationResult(image, false));
            }

            var basePath = _configuration.GetSection("ImageBasePath").Value;
            var filePath = Path.Combine(basePath, image.FilePath);

            if(!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var contentType = GetContentType(image.ExtensionName);

            return File(System.IO.File.OpenRead(filePath), contentType);
        }

        private string GetContentType(string fileExtension)
        {
            // Определите MIME-тип на основе расширения файла
            switch (fileExtension.ToLower())
            {
                case "jpg":
                case "jpeg":
                    return "image/jpeg";
                case "png":
                    return "image/png";
                case "gif":
                    return "image/gif";
                // Добавьте другие типы изображений по необходимости
                default:
                    return "application/octet-stream";
            }
        }
    }
}
