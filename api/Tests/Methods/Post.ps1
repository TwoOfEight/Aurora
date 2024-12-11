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

$jsonBody = $body | ConvertTo-Json -Depth 10

$response = Invoke-RestMethod -Uri $EndpointUri -Method Post -Body $jsonBody -Headers $headers -ContentType "application/json"

return $response 
