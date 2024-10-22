#!/bin/sh
envsubst '$NGINX_INTERNAL_PORT $FRONTEND_PORT $BACKEND_PORT' < /etc/nginx/conf.d/default.conf.template > /etc/nginx/conf.d/default.conf
exec nginx -g 'daemon off;'
