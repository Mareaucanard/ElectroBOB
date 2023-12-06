FROM node:21-alpine

COPY . /web-client
WORKDIR /web-client

RUN yarn

RUN npx nuxi generate

RUN cp /var/mobile-app/*.apk .output/public/client.apk

CMD ["npx", "serve", ".output/public"]
