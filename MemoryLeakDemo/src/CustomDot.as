package
{
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.filters.DropShadowFilter;

	public class CustomDot extends Sprite
	{
		private var _bitmapData:BitmapData;
		
		public function CustomDot() 
		{
			
			//DRAW GRAPHICS - RED DOT
			graphics.beginFill(0xFF0000);
			graphics.drawCircle(100,100, 50);
			graphics.endFill();
			
			//ADD A FILTER - FOR FUN
			filters = [new DropShadowFilter (2,2,30,0xcccccc)];
			
			//CREATE A BITMAPDATA, JUST TO 'USE' MORE RAM AND MAKE A DRAMATIC EXAMPLE.
			_bitmapData = new BitmapData (300, 300, true, 0xFF0000);
			
			
		}
	}
}