using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.IdentityHub
{
    /// <summary>
    /// Represents metadata for a profile picture, including the file name and content type.
    /// </summary>
    public class ProfilePictureMeta
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePictureMeta"/> class with the specified file name.
        /// </summary>
        /// <param name="fileName">The name of the profile picture file.</param>
        public ProfilePictureMeta(string fileName) => FileName = fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePictureMeta"/> class with the specified file name and content type.
        /// </summary>
        /// <param name="fileName">The name of the profile picture file.</param>
        /// <param name="contentType">The MIME type of the profile picture file (e.g., "image/jpeg").</param>
        public ProfilePictureMeta(string fileName, string contentType) : this(fileName)
        {
            ContentType = contentType;
        }

        /// <summary>
        /// Gets or sets the name of the profile picture file.
        /// </summary>
        /// <value>
        /// The name of the file, including its extension (e.g., "profile.jpg").
        /// </value>
        public string FileName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the MIME type of the profile picture file.
        /// </summary>
        /// <value>
        /// The content type (e.g., "image/jpeg", "image/png").</value>
        public string ContentType { get; set; } = default!;
    }
}
