$PackagePath = "c:\Code\AzureDeploy\VSTS\deploy\deploy.zip"
$ResourceGroupName = "DNOurWebApp"
$AppName = "DNOurWebApp"

if ((Test-Path $PackagePath)) {
	$xml = Get-AzureRmWebAppPublishingProfile -Name $AppName `
		-ResourceGroupName $ResourceGroupName `
		-OutputFile temp.xml -Format WebDeploy -ErrorAction Stop
		
	$username = ([xml]$xml).SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userName").value
	$password = ([xml]$xml).SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userPWD").value
	$url = ([xml]$xml).SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@publishUrl").value
	$siteName = ([xml]$xml).SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@msdeploySite").value
	
	echo "UserName: " $username
	echo "Password: " $password
	echo "TargetUrl: " $url
	echo "SiteName: " $siteName
	
	del temp.xml
	
	echo "Attempting sync"

	$msdeployArguments = 
	'-verb:sync ' +
	"-source:package='$PackagePath' " + 
	"-dest:iisApp,ComputerName=https://$url/msdeploy.axd?site=$siteName,UserName=$username,Password=$password,AuthType='Basic',includeAcls='False' "

	$commandLine = '&"C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe" --% ' + $msdeployArguments
	Invoke-Expression $commandLine
	
	echo "deployment complete"
}
else{
	echo "Can't find package."
}

