namespace WorkWrapper.Documents.Models
{
    public class DocumentUploadRequest : IDocumentUploadRequest
    {
        public DocumentUploadRequest(IDocumentProfile documentProfile)
        {
            DocProfile = documentProfile;
        }

        /// <inheritdoc />
        public IDocumentProfile DocProfile { get; }

        /// <inheritdoc />
        public bool WarningForRequiredAndDisabledFields { get; set; }

        /// <inheritdoc />
        public bool KeepLocked { get; set; }

        /// <inheritdoc />
        public bool InheritProfileFromFolder { get; set; }

        /// <inheritdoc />
        public IEnumerable<ITrustee> UserTrustees { get; set; }

        /// <inheritdoc />
        public IEnumerable<ITrustee> GroupTrustees { get; set; }
    }
}
