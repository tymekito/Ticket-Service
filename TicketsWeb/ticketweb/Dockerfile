FROM node:16-alpine

# Standard frontend building
USER root
WORKDIR /app
COPY package*.json ./
RUN npm config set fund false --global && npm install && npm install live-server -g

COPY . ./
RUN npm run build 
RUN npm run lint

WORKDIR /app/dist

CMD ["live-server", "--port=8080", "--entry-file=index.html" ]
