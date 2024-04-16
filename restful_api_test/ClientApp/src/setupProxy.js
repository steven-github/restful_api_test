const { createProxyMiddleware } = require("http-proxy-middleware");

module.exports = function (app) {
  app.use(
    "/api",
    createProxyMiddleware({
      target: "https://localhost:7011/api",
      changeOrigin: true,
    })
  );
  app.use(
    "/api2",
    createProxyMiddleware({
      target: "http://localhost:7011/api",
      changeOrigin: true,
    })
  );
};
