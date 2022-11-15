namespace UsefulLinksDuringWarUa.Entities
{
    public class UrlLink
    {
        private string Url { get; set; }
        private string Text { get; set; }
        private string Description { get; set; }

        public UrlLink(string url, string text, string description = "")
        {
            Url = url;
            Text = text;
            Description = description;
        }

        public string BuildHtmlString()
        {
            return $"<pre>*</pre><a href='{Url}'>&#160 {Text}</a>{Description}";
        }
    }
}