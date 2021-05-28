#!/bin/bash

#  <author>Nasr Aldin</author>
#  <email>nasr2ldin@gmail.com</email>
#  <github>https://github.com/nasraldin</github>
#  <date>05/10/2021 08:31 AM</date>

set -e
run_cmd="dotnet run --server.urls https://*:443"

until dotnet ef database update; do
    echo >&2 "Database Server is starting up"
    sleep 1
done

echo >&2 "Database Server is up - executing command"
exec $run_cmd