namespace PaginableCollections.AspNetCore.IntegrationTests.LinkBased
{
    using System.Linq;
    using System.Net.Http;

    public class LinkParser
    {
        public string First { get; set; }
        public string Previous { get; set; }
        public string Current { get; set; }
        public string Next { get; set; }
        public string Last { get; set; }

        public LinkParser(HttpResponseMessage response)
        {
            ParsePageLinks(response);
        }

        public void ParsePageLinks(HttpResponseMessage response)
        {
            string linkHeader = response.Headers.Where(x => x.Key == "Link").FirstOrDefault().Value.FirstOrDefault();
            if (linkHeader != null)
            {
                string[] links = linkHeader.Split(",");
                foreach (string link in links)
                {
                    string[] segments = link.Split(";");
                    if (segments.Length < 2)
                        continue;

                    string linkPart = segments[0].Trim();
                    if (!linkPart.StartsWith("<") || !linkPart.EndsWith(">")) //$NON-NLS-1$ //$NON-NLS-2$
                        continue;
                    linkPart = linkPart.Substring(1, linkPart.Length - 2);

                    for (int i = 1; i < segments.Length; i++)
                    {
                        string[] rel = segments[i].Trim().Split("="); //$NON-NLS-1$
                        if (rel.Length < 2 || !"rel".Equals(rel[0]))
                            continue;

                        string relValue = rel[1];
                        if (relValue.StartsWith("\"") && relValue.EndsWith("\"")) //$NON-NLS-1$ //$NON-NLS-2$
                            relValue = relValue.Substring(1, relValue.Length - 2);

                        if ("first".Equals(relValue))
                            First = linkPart?.Trim();
                        else if ("last".Equals(relValue))
                            Last = linkPart?.Trim();
                        else if ("next".Equals(relValue))
                            Next = linkPart?.Trim();
                        else if ("prev".Equals(relValue))
                            Previous = linkPart?.Trim();
                        else if ("current".Equals(relValue))
                            Current = linkPart?.Trim();
                    }
                }
            }
        }
    }
}