FROM node:21-alpine

COPY . /electro-bob
WORKDIR /electro-bob

RUN yarn install
RUN yarn add serve

RUN npx nuxi generate

# COPY --from=internal/web /var/electroBOB.apk dist/client.apk

ENV API_URL=API_URL

CMD ["npx", "serve", "dist"]
