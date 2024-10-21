FROM node:21-alpine

WORKDIR /relayserver

COPY package*.json ./
RUN npm ci
COPY dist ./dist

USER node
ENV PORT=3000
EXPOSE 3000
CMD ["/bin/ash", "-c", "npm run start"]