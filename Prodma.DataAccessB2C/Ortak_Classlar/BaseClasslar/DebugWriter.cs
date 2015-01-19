    using System.Text;
using System.IO;
using System.Diagnostics;

public class DebugWriter : TextWriter
{

public override Encoding Encoding
{
get { return new UnicodeEncoding(); }
}
public override void Write(char[] buffer, int index, int count)
{
Debug.WriteLine(new string(buffer, index, count));
//context.Log = new DebugWriter(); 
}
}
