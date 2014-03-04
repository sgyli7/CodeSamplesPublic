@ECHO OFF 
REM - ///////////////////////////////////////////
REM - //  1. Instructions
REM - ///////////////////////////////////////////
REM - Change all URLS in section #2 to your file locations



REM - ///////////////////////////////////////////
REM - //  2. Executable Code
REM - ///////////////////////////////////////////

REM - Run AsDoc
"C:\Program Files\Adobe\Flex Builder 3b2\sdks\3.0.0\bin\asdoc.exe" -sp "C:\workspaces\PureMVC\PureMVCTemplate\src" -ds "C:\workspaces\PureMVC\PureMVCTemplate\src" -output "C:\workspaces\PureMVC\PureMVCTemplate\documentation\output"

REM - Pause and Prompt User that the documentation is about to open
ECHO ABOUT TO OPEN DOCUMENTATION IN BROWSER
pause

REM - Open the outputted documentation and close the batch window
C:\workspaces\PureMVC\PureMVCTemplate\documentation\output\index.html
exit


REM - ///////////////////////////////////////////
REM - //  3. Release Notes
REM - ///////////////////////////////////////////
REM - I tried to shorten output and exclude the org.puremvc package 
REM - It didn't work with this line;
REM - -exclude-classes org.puremvc.core.controller.Controller org.puremvc.core.model.Model org.puremvc.core.view.View org.puremvc.interfaces.ICommand org.puremvc.interfaces.IController org.puremvc.interfaces.IFacade org.puremvc.interfaces.IMediator org.puremvc.interfaces.IModel org.puremvc.interfaces.INotification org.puremvc.interfaces.INotifier

