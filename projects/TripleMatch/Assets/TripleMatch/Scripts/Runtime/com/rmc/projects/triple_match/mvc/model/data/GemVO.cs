
namespace com.rmc.projects.triple_match.model.data
{

	public class GemVO
	{

		public int RowIndex;
		public int ColumnIndex;
		public int GemTypeIndex;


		public GemVO (int rowIndex, int columnIndex, int gemTypeIndex)
		{

			RowIndex = rowIndex;
			ColumnIndex = columnIndex;
			GemTypeIndex = gemTypeIndex;

			//
			//Debug.Log (this);
		}


		/// <summary>
		/// Show nice debuggable output
		/// </summary>
		override public string ToString ()
		{
			return "[GemVO (r="+RowIndex+", c="+ColumnIndex+", gti="+GemTypeIndex+")]";

		}

	}
}
