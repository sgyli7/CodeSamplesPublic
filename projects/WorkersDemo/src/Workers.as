/*******************************************************************************************************************************************
 * This is an automatically generated class. Please do not modify it since your changes may be lost in the following circumstances:
 *     - Members will be added to this class whenever an embedded worker is added.
 *     - Members in this class will be renamed when a worker is renamed or moved to a different package.
 *     - Members in this class will be removed when a worker is deleted.
 *******************************************************************************************************************************************/

package 
{
	
	import flash.utils.ByteArray;
	
	public class Workers
	{
		
		[Embed(source="../workerswfs/CustomWorker.swf", mimeType="application/octet-stream")]
		private static var CustomWorker_ByteClass:Class;
		
		[Embed(source="../workerswfs/SuperWorker.swf", mimeType="application/octet-stream")]
		private static var SuperWorker_ByteClass:Class;
		public static function get CustomWorker():ByteArray
		{
			return new CustomWorker_ByteClass();
		}
		
		public static function get SuperWorker():ByteArray
		{
			return new SuperWorker_ByteClass();
		}
		
		
	}
}
