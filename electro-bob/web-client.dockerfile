FROM node:21-alpine

COPY . /web-client
WORKDIR /web-client

RUN yarn
RUN yarn add serve

RUN npx nuxi generate

# COPY --from=internal/web /var/electroBOB.apk dist/client.apk

ENV API_URL=API_URL

CMD ["npx", "serve", "dist"]
