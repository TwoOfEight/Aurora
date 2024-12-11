param(
    [string]$Message,
    [string]$EndpointUri,
    [string]$BearerToken,
    [hashtable]$Body
)

Write-Output $Message

$headers = @{
    "Authorization" = "Bearer $BearerToken"
}

$response = Invoke-RestMethod -Uri $EndpointUri -Method Get -Headers $headers -ContentType "application/json"

return $response | Format-Table
