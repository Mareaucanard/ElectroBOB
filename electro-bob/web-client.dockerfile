FROM node:21-alpine

COPY . /electro-bob
WORKDIR /electro-bob

RUN yarn global add nuxt
RUN yarn global add nodejs
RUN yarn install

ENV API_URL=API_URL

RUN yarn run build

CMD ["node", ".output/server/index.mjs"]