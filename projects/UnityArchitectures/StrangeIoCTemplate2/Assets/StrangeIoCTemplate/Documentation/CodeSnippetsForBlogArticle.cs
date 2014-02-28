/*
 * 



1. CONTEXT - SETUP BINDING

commandBinder.Bind<GameListPropertyChangeSignal>().To<GameListPropertyChangeCommmand>();

2. COMMAND - HANDLE BINDING

public override void Execute()
{

	switch (propertyChangeSignalVO.propertyChangeType) {

	case PropertyChangeType.CLEAR:
		//ASK TO CLEAR THE MODEL
		iCustomModel.doClearGameList(); 
		break;
	case PropertyChangeType.UPDATE:
		//ASK TO UPDATE A VALUE IN THE MODEL
		iCustomModel.gameList = propertyChangeSignalVO.value as List<string>;
		break;
	case PropertyChangeType.UPDATED:
		//FOR THIS PROJECT, THE VIEW LISTENS DIRECTLY TO 'UPDATED'
		//OPTIONALLY, WE COULD ALSO DO SOMETHING HERE IF NEEDED
		break;
	case PropertyChangeType.REQUEST:
		//FORCE THE MODEL TO RE-SEND 'UPDATED' (WITH NO CHANGE)
		//THIS IS VERY COMMON IN APPS (E.G. A TEMPORARY A DIALOG PROMPT)
		iCustomModel.doRefreshGameList();
		break;
	default:
		#pragma warning disable 0162
		throw new SwitchStatementException(propertyChangeSignalVO.propertyChangeType.ToString());
		break;
		#pragma warning restore 0162

	}

}


3. MODEL - DISPATCH CHANGES

private List<string> _gameList;
public List<string> gameList 
{
	get 
	{
		return _gameList;
	}
	set 
	{
		//TODO: CONSIDER ALTERNATIVE THAT CHECKS "_gameList != value" BEFORE DISPATCHING
		_gameList = value;
		gameListPropertyChangeSignal.Dispatch (new PropertyChangeSignalVO(PropertyChangeType.UPDATED, _gameList) );
	}
}


4. VIEW - HANDLE CHANGES

private void _onGameListPropertyChangeSignal (PropertyChangeSignalVO aPropertyChangeSignalVO)
{
	if (aPropertyChangeSignalVO.propertyChangeType == PropertyChangeType.UPDATED) {

		doRenderLayout(aPropertyChangeSignalVO.value as List<string>);
	}
}



 * 
 * 
 **/