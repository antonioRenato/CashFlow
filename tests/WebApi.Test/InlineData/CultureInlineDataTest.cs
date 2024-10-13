using System.Collections;

namespace WebApi.Test.InlineData
{
    public class CultureInlineDataTest : IEnumerable<Object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new Object[] { "fr" };
            yield return new Object[] { "pt-BR" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
