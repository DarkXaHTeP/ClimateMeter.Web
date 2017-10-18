#!/usr/bin/env bash

echo "Starting ClimateMeter.Web..."
sudo docker run --name web \
    --net dockernet \
    -e CONSUL_HOST=consul \
    -e CONSUL_PORT=8500 \
    -e VIRTUAL_HOST=climatemeter.darkxahtep.co.ua \
    -e VIRTUAL_PORT=5000 \
    -e LETSENCRYPT_HOST=climatemeter.darkxahtep.co.ua \
    -e LETSENCRYPT_EMAIL=darkxahtep@gmail.com \
    --restart always -d -it darkxahtep/climatemeter-web