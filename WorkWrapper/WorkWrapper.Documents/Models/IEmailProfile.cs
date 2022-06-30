namespace WorkWrapper.Documents.Models;

internal interface IEmailProfile : IDocumentProfile
{
    public string Subject { get; set; }

    public string Bcc { get; set; }

    public string Cc { get; set; }

    public string ConversationId { get; set; }

    public string ConversationName { get; set; }

    public string From { get; set; }

    public string To { get; set; }

    bool HasAttachment { get; set; }

    DateTime ReceivedDate { get; set; }

    DateTime SentDate { get; set; }
}