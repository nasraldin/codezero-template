# Add the hosts name to windows hosts file
#  
# by Nasr Aldin
# nasr2ldin@gmail.com
# https://github.com/nasraldin
# 

$file = "C:\Windows\System32\drivers\etc\hosts"
$local = "127.0.0.1"
$array = @("api.dev", "sso.local", "phpmyadmin.local", "seq.local", "redis.local", "camunda.local", "rabbitmq.local", "portainer.local")

function Remove-Host([string]$filename, [string]$ip, [string]$hostname) {
  $check = (Get-Content $filename) | Where-Object {
    $_ -match $ip + "`t" + $hostname
  }
  if($check) {
    (Get-Content $filename) | Where-Object {
      $_ -notmatch $ip + "`t" + $hostname
    } | Set-Content -encoding default $filename

    Write-Output "$hostname found in hosts. Removing now... - OK"
  } else {
    Write-Output "$hostname was not found in hosts."
  }
}

function Add-Host([string]$filename, [string]$ip, [string]$hostname) {
  # clear old if exists
	Remove-Host $file $local $hostname

  # add hosts
	$ip + "`t" + $hostname | Out-File -encoding ASCII -append $filename
  Write-Output "$hostname was added succesfully - OK"
}

try {
	if ($args[0] -eq "add") {
    Foreach ($name in $array) {
      Add-Host $file $local $name
    }
	} elseif ($args[0] -eq "remove") {
    Foreach ($name in $array) {
      Remove-Host $file $local $name
    }
	} elseif ($args[0] -eq "show") {
		echo $file
		Get-Content $file
	}
	else {
		throw "Invalid operation '" + $args[0] + "' - must be one of 'add', 'remove', 'show'."
	}
} catch  {
	Write-Host $error[0]
	Write-Host "`nUsage:`n host add`n host remove`n host show`n"
}