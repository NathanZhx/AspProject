using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class EmailEntity
{
    public string FromEmailAddress { get; set; } = string.Empty;
    public string ToEmailAddress { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string EmailBodyMessage { get; set; } = string.Empty;

    //[ValidateNever]
    //public string AttachmentURL { get; set; }
}