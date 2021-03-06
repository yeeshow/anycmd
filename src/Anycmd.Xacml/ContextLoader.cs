using System;
using System.IO;
using System.Xml;

namespace Anycmd.Xacml
{
    using Context;

    /// <summary>
    /// 帮助从xml数据加载包含一个请求或响应文档的帮助类。
    /// </summary>
    /// <remarks>Reading a Response context document is not really needed by the implementation but it's used to
    /// compare the Response emited by the evaluation with the Response provided in the Conformance tests.</remarks>
    public static class ContextLoader
    {
        #region Constructor

        #endregion

        #region Static methods

        /// <summary>
        /// Creates an instace of the ContextDocument using the provided Xml document string.
        /// </summary>
        /// <param name="xmlDocument">The Xml document fragment.</param>
        /// <returns>An instance of a ContextDocument/</returns>
        public static ContextDocumentReadWrite LoadContextDocument(string xmlDocument)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            XacmlVersion version = GetXacmlVersion(new StreamReader(xmlDocument));

            return LoadContextDocument(new XmlTextReader(new StringReader(xmlDocument)), version);
        }

        /// <summary>
        /// Creates an instace of the ContextDocument using the stream provided with an Xml document.
        /// </summary>
        /// <param name="xmlDocument">The stream containing an Xml document.</param>
        /// <returns>An instance of a ContextDocument.</returns>
        public static ContextDocumentReadWrite LoadContextDocument(Stream xmlDocument)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            XacmlVersion version = GetXacmlVersion(new StreamReader(xmlDocument));

            xmlDocument.Position = 0;

            return LoadContextDocument(new XmlTextReader(new StreamReader(xmlDocument)), version);
        }

        /// <summary>
        /// Creates an instace of the ContextDocument using the provided Xml document string.
        /// </summary>
        /// <param name="xmlDocument">The Xml document fragment.</param>
        /// <param name="schemaVersion">The version of the schema used to validate the document.</param>
        /// <returns>An instance of a ContextDocument/</returns>
        public static ContextDocumentReadWrite LoadContextDocument(string xmlDocument, XacmlVersion schemaVersion)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            return LoadContextDocument(new XmlTextReader(new StringReader(xmlDocument)), schemaVersion);
        }

        /// <summary>
        /// Creates an instace of the ContextDocument using the stream provided with an Xml document.
        /// </summary>
        /// <param name="xmlDocument">The stream containing an Xml document.</param>
        /// <param name="schemaVersion">The version of the schema used to validate the document.</param>
        /// <returns>An instance of a ContextDocument.</returns>
        public static ContextDocumentReadWrite LoadContextDocument(Stream xmlDocument, XacmlVersion schemaVersion)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            return LoadContextDocument(new XmlTextReader(new StreamReader(xmlDocument)), schemaVersion);
        }

        /// <summary>
        /// Creates an instance of the ContextDocument using the XmlReader instance provided.
        /// </summary>
        /// <param name="reader">The XmlReader used to read the Xml document.</param>
        /// <param name="schemaVersion">The versoin of the schema used to validate the document.</param>
        /// <returns>An instance of a ContextDocument.</returns>
        public static ContextDocumentReadWrite LoadContextDocument(XmlReader reader, XacmlVersion schemaVersion)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            return new ContextDocument(reader, schemaVersion);
        }
        /// <summary>
        /// Creates an instace of the ContextDocument using the provided Xml document string.
        /// </summary>
        /// <param name="xmlDocument">The Xml document fragment.</param>
        /// <param name="access">The access to the document (read-write/read-only)</param>
        /// <returns>An instance of a ContextDocument/</returns>
        public static ContextDocumentReadWrite LoadContextDocument(string xmlDocument, DocumentAccess access)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            XacmlVersion version = GetXacmlVersion(new StreamReader(xmlDocument));

            return LoadContextDocument(new XmlTextReader(new StringReader(xmlDocument)), version, access);
        }

        /// <summary>
        /// Creates an instace of the ContextDocument using the stream provided with an Xml document.
        /// </summary>
        /// <param name="xmlDocument">The stream containing an Xml document.</param>
        /// <param name="access">The access to the document (read-write/read-only)</param>
        /// <returns>An instance of a ContextDocument.</returns>
        public static ContextDocumentReadWrite LoadContextDocument(Stream xmlDocument, DocumentAccess access)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            XacmlVersion version = GetXacmlVersion(new StreamReader(xmlDocument));

            xmlDocument.Position = 0;

            return LoadContextDocument(new XmlTextReader(new StreamReader(xmlDocument)), version, access);
        }

        /// <summary>
        /// Creates an instace of the ContextDocument using the provided Xml document string.
        /// </summary>
        /// <param name="xmlDocument">The Xml document fragment.</param>
        /// <param name="schemaVersion">The version of the schema used to validate the document.</param>
        /// <param name="access">The access to the document (read-write/read-only)</param>
        /// <returns>An instance of a ContextDocument/</returns>
        public static ContextDocumentReadWrite LoadContextDocument(string xmlDocument, XacmlVersion schemaVersion, DocumentAccess access)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            return LoadContextDocument(new XmlTextReader(new StringReader(xmlDocument)), schemaVersion, access);
        }

        /// <summary>
        /// Creates an instace of the ContextDocument using the stream provided with an Xml document.
        /// </summary>
        /// <param name="xmlDocument">The stream containing an Xml document.</param>
        /// <param name="schemaVersion">The version of the schema used to validate the document.</param>
        /// <param name="access">The access to the document (read-write/read-only)</param>
        /// <returns>An instance of a ContextDocument.</returns>
        public static ContextDocumentReadWrite LoadContextDocument(Stream xmlDocument, XacmlVersion schemaVersion, DocumentAccess access)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument");
            }

            return LoadContextDocument(new XmlTextReader(new StreamReader(xmlDocument)), schemaVersion, access);
        }

        /// <summary>
        /// Creates an instance of the ContextDocument using the XmlReader instance provided.
        /// </summary>
        /// <param name="reader">The XmlReader used to read the Xml document.</param>
        /// <param name="schemaVersion">The versoin of the schema used to validate the document.</param>
        /// <param name="access">The access to the document (read-write/read-only)</param>
        /// <returns>An instance of a ContextDocument.</returns>
        public static ContextDocumentReadWrite LoadContextDocument(XmlReader reader, XacmlVersion schemaVersion, DocumentAccess access)
        {
            return ContextDocument.Create(reader, schemaVersion, access);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Reads the document to the first Request or Response element and compares the Namespace of that
        /// element with the namespaces for the different versions of the spec and determines the version of the
        /// schema that will be used.
        /// </summary>
        /// <param name="textReader">A reader positioned and ready to process.</param>
        /// <returns>The vesion of the schema required in the policy document.</returns>
        private static XacmlVersion GetXacmlVersion(TextReader textReader)
        {
            var reader = new XmlTextReader(textReader);
            while (reader.Read())
            {
                // xml是区分大小写的，比较字符串的时候不需要忽略大小写
                switch (reader.LocalName)
                {
                    case Consts.ContextSchema.ResponseElement.Response:
                    case Consts.ContextSchema.RequestElement.Request:
                        switch (reader.NamespaceURI)
                        {
                            case Consts.Schema1.Namespaces.Context:
                                return XacmlVersion.Version11;
                            case Consts.Schema2.Namespaces.Context:
                                return XacmlVersion.Version20;
                        }
                        break;
                }
            }
            throw new EvaluationException(Properties.Resource.exc_invalid_document_format_no_policyorpolicyset);
        }

        #endregion
    }
}
