#!/usr/bin/env bash

echo "Starting ClimateMeter.Web..."
sudo docker run --name web \
    --net dockernet \
    -e VIRTUAL_HOST=climatemeter.darkxahtep.co.ua \
    -e VIRTUAL_PORT=5000 \
    -e LETSENCRYPT_HOST=climatemeter.darkxahtep.co.ua \
    -e LETSENCRYPT_EMAIL=darkxahtep@gmail.com \
    --restart always -d darkxahtep/climatemeter-web