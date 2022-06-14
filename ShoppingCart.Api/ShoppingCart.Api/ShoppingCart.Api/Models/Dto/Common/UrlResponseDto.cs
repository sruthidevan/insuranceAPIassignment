namespace InsuranceCalculator.Api.Models.Dto.Common
{
    public class UrlResponseDto
    {
        public UrlResponseDto()
        {
        }

        public UrlResponseDto(string href)
        {
            Href = href;
        }

        public string Href { get; }
    }
}
