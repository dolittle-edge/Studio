FROM node:11.6 AS build

# Copy package.json and install dependencies
WORKDIR /Source/
COPY ./Web/package.json ./Web/package.json
WORKDIR /Source/Web/
RUN yarn install

# Build Web project
WORKDIR /Source/
COPY ./Web/ ./Web/
WORKDIR /Source/Web/
RUN yarn build

# Build runtime image
FROM nginx:1.15-alpine
COPY --from=build /Source/Web/dist /usr/share/nginx/html
COPY --from=build /Source/Web/nginx-default.conf /etc/nginx/conf.d/default.conf