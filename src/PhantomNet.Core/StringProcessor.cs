using System.Text.RegularExpressions;

namespace PhantomNet
{
    public class StringProcessor
    {
        public string ToAscii(string source)
        {
            string unicode = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴđĐ",
                ascii = "aaaaaaaaaaaaaaaaaeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYdD";

            for (var i = 0; i < unicode.Length; i++)
            {
                source = source.Replace(unicode[i], ascii[i]);
            }
            return source;
        }

        public string ToUrlFriendly(string source)
        {
            source = ToAscii(source).Trim().ToLower();
            source = source.Replace(' ', '-');
            source = source.Replace("&nbsp;", "-");
            source = new Regex("[^0-9a-z-]").Replace(source, string.Empty);
            while (source.IndexOf("--") > -1)
            {
                source = source.Replace("--", "-");
            }
            return source;

        }
    }
}
