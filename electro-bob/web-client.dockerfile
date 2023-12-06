FROM node:21-alpine

COPY . /web-client
WORKDIR /web-client

RUN yarn
RUN yarn add serve

RUN npx nuxi generate

COPY --from=internal/web /var/electroBOB.apk .output/public/client.apk

CMD ["npx", "serve", ".output/public"]
