using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace RailswareMailtrap.Application.Models.Request
{
    public class Attachment
    {
        public string Content { get; set; }
        public string Filename { get; set; }
        public string Type { get; set; }
        public string Disposition { get; set; }
    }
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<IFormFile, Attachment>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ContentType))
                .ForMember(dest => dest.Disposition, opt => opt.MapFrom(src => "attachment"))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => ConvertToBase64String(src).Result));
        }

        private async Task<string> ConvertToBase64String(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    return Convert.ToBase64String(fileBytes); // You might want to choose another format or encoding
                }
            }
            return null;
        }
    }
}
