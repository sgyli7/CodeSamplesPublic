package
{
	import flash.display.Sprite;
	
	import as3.mongo.Mongo;
	import as3.mongo.db.DB;
	import as3.mongo.db.credentials.Credentials;
	
	public class MongoDBAS3Demo extends Sprite
	{

		private var mongo:Mongo;
		public function MongoDBAS3Demo()
		{
			mongo = new Mongo("mongodb://ds035167.mongolab.com:35167/mongodbdatabase");
			
			/* Add a handler to the connected Signal object to hook
			in to when the database has established a connection */
			mongo.db("mongodbdatabase").connectionFailed.add(_onDBConnectionFailed);
			mongo.db("mongodbdatabase").connected.add(_onDBConnected);
			
			/* Call connect() to try a connection with mongodb */
			mongo.db("mongodbdatabase").connect();
			
			
		}
		
		/* The Signal handler must accept a DB object, it is
		a referece to the mongo.db("myDatabase") object. */
		public function _onDBConnected(db:DB):void
		{
			/*...do stuff...*/
			trace ("ok: " + db);
		}
		
		/* The Signal handler must accept a DB object, it is
		a referece to the mongo.db("myDatabase") object. */
		public function _onDBConnectionFailed(db:DB):void
		{
			trace ("_onDBConnectionFailed" + db);
			
			
			return
			
			/* First create a Credentials object using your username/password */
			var dbCredentials:Credentials = new Credentials("db_user_name", "db_user_password");
			
			/* Add callback handlers for authentication problems and authenticated
			Signals objects */
			mongo.db("mongodbdatabase").authenticationProblem.add(onAuthenticationProblem);
			mongo.db("mongodbdatabase").authenticated.add(onDBAuthenticated);
			
			/* Set the credentials to the database */
			mongo.db("mongodbdatabase").setCredentials(dbCredentials);
			
			/* Run the authenticate mongodb command */
			mongo.db("mongodbdatabase").authenticate();
		}
		
		public function onAuthenticationProblem(db:DB):void
		{
			trace("There was a problem authenticating with the database.");
		}
		
		public function onDBAuthenticated(db:DB):void
		{
			/*...do stuff...*/
			trace("There was good");
		}
	}
}