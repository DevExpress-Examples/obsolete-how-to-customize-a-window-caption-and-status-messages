;#DropDB CustomizeWindowSolutionEasyTest

#Application CustomizeWindowSolutionWin
#Application CustomizeWindowSolutionWeb

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef CustomizeWindowSolutionWeb
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef CustomizeWindowSolutionWin
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
