﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domains;
using WebAPI.Utils.OCR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly OcrService _ocrService;
        public OcrController(OcrService ocrService)
        {
            _ocrService = ocrService;
        }

        [HttpPost]
        public async Task<IActionResult> RecognizeText([FromForm] FileUploadModel file)
        {
            try
            {
                if (file == null || file.Image == null)
                {
                    return BadRequest("Nenhuma imagem foi fornecida");
                }

                using (var stream = file.Image.OpenReadStream())
                {
                  var result = await _ocrService.RecognizeTextAsync(stream);
                return Ok(result);
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao processar a imagem");
            }
        }
    }
}
