$apiUri = "http://localhost:5271/api/User"
$currentDirectory = Get-Location

$ALERT = "$currentDirectory\Methods\Alert.ps1"
$GET = "$currentDirectory\Methods\Get.ps1"
$POST = "$currentDirectory\Methods\Post.ps1"

$bearerToken = ""

$newUser = @{
    userName = "mack.the.knife"
    name = "Michael Seaborn"
    email = "mack.the.knife@protonmail.com"
}

$createMsg = . $ALERT -Message "Creating a new user"
Write-Output $newUser = . $POST -EndpointUri $apiUri -Message $createMsg -BearerToken $bearerToken -Body $newUser

$getByIdMsg = . $ALERT -Message "Getting user by id"
$id = $newUser.$id
. $GET -EndpointUri "$apiUri/$id" -Message $getByIdMsg -BearerToken $bearerTokenj

$getAllMsg = . $ALERT -Message "Getting all users"
. $GET -EndpointUri $apiUri -Message $getAllMsg -BearerToken $bearerTokenj
