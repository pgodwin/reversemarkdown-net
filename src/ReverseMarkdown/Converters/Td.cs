
using HtmlAgilityPack;
using System;

namespace ReverseMarkdown.Converters
{
	public class Td
		: ConverterBase
	{
		public Td(Converter converter)
			: base(converter)
		{
			this.Converter.Register("td", this);
			this.Converter.Register("th", this);
		}

		public override string Convert(HtmlNode node)
		{
			string content = this.TreatChildren(node);
            // Fix up newlines in tables (Issue #21)
            content = content.Replace(Environment.NewLine, "<br>");
            return string.Format(" {0} |", content);
		}
	}
}
