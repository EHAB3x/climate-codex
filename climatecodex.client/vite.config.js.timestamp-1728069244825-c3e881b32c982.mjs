// vite.config.js
import { fileURLToPath, URL } from "node:url";
import { defineConfig } from "file:///C:/Users/user/source/repos/ClimateCodex/climatecodex.client/node_modules/vite/dist/node/index.js";
import plugin from "file:///C:/Users/user/source/repos/ClimateCodex/climatecodex.client/node_modules/@vitejs/plugin-react/dist/index.mjs";
import fs from "fs";
import path from "path";
import child_process from "child_process";
import { env } from "process";
import svgr from "file:///C:/Users/user/source/repos/ClimateCodex/climatecodex.client/node_modules/vite-plugin-svgr/dist/index.js";
var __vite_injected_original_import_meta_url = "file:///C:/Users/user/source/repos/ClimateCodex/climatecodex.client/vite.config.js";
var baseFolder = env.APPDATA !== void 0 && env.APPDATA !== "" ? `${env.APPDATA}/ASP.NET/https` : `${env.HOME}/.aspnet/https`;
var certificateName = "climatecodex.client";
var certFilePath = path.join(baseFolder, `${certificateName}.pem`);
var keyFilePath = path.join(baseFolder, `${certificateName}.key`);
if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
  if (0 !== child_process.spawnSync(
    "dotnet",
    [
      "dev-certs",
      "https",
      "--export-path",
      certFilePath,
      "--format",
      "Pem",
      "--no-password"
    ],
    { stdio: "inherit" }
  ).status) {
    throw new Error("Could not create certificate.");
  }
}
var target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` : env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(";")[0] : "https://localhost:7093";
var vite_config_default = defineConfig({
  plugins: [plugin(), svgr()],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", __vite_injected_original_import_meta_url))
    }
  },
  server: {
    proxy: {
      "^/weatherforecast": {
        target,
        secure: false
      }
    },
    port: 5173,
    https: {
      key: fs.readFileSync(keyFilePath),
      cert: fs.readFileSync(certFilePath)
    }
  },
  css: {
    preprocessorOptions: {
      scss: {
        additionalData: `
          @import "src/styles/colors.scss";
          @import "src/styles/media.scss";
          `
      }
    }
  }
});
export {
  vite_config_default as default
};
//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAic291cmNlcyI6IFsidml0ZS5jb25maWcuanMiXSwKICAic291cmNlc0NvbnRlbnQiOiBbImNvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9kaXJuYW1lID0gXCJDOlxcXFxVc2Vyc1xcXFx1c2VyXFxcXHNvdXJjZVxcXFxyZXBvc1xcXFxDbGltYXRlQ29kZXhcXFxcY2xpbWF0ZWNvZGV4LmNsaWVudFwiO2NvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9maWxlbmFtZSA9IFwiQzpcXFxcVXNlcnNcXFxcdXNlclxcXFxzb3VyY2VcXFxccmVwb3NcXFxcQ2xpbWF0ZUNvZGV4XFxcXGNsaW1hdGVjb2RleC5jbGllbnRcXFxcdml0ZS5jb25maWcuanNcIjtjb25zdCBfX3ZpdGVfaW5qZWN0ZWRfb3JpZ2luYWxfaW1wb3J0X21ldGFfdXJsID0gXCJmaWxlOi8vL0M6L1VzZXJzL3VzZXIvc291cmNlL3JlcG9zL0NsaW1hdGVDb2RleC9jbGltYXRlY29kZXguY2xpZW50L3ZpdGUuY29uZmlnLmpzXCI7aW1wb3J0IHsgZmlsZVVSTFRvUGF0aCwgVVJMIH0gZnJvbSBcIm5vZGU6dXJsXCI7XHJcblxyXG5pbXBvcnQgeyBkZWZpbmVDb25maWcgfSBmcm9tIFwidml0ZVwiO1xyXG5pbXBvcnQgcGx1Z2luIGZyb20gXCJAdml0ZWpzL3BsdWdpbi1yZWFjdFwiO1xyXG5pbXBvcnQgZnMgZnJvbSBcImZzXCI7XHJcbmltcG9ydCBwYXRoIGZyb20gXCJwYXRoXCI7XHJcbmltcG9ydCBjaGlsZF9wcm9jZXNzIGZyb20gXCJjaGlsZF9wcm9jZXNzXCI7XHJcbmltcG9ydCB7IGVudiB9IGZyb20gXCJwcm9jZXNzXCI7XHJcbmltcG9ydCBzdmdyIGZyb20gXCJ2aXRlLXBsdWdpbi1zdmdyXCI7XHJcbmNvbnN0IGJhc2VGb2xkZXIgPVxyXG4gIGVudi5BUFBEQVRBICE9PSB1bmRlZmluZWQgJiYgZW52LkFQUERBVEEgIT09IFwiXCJcclxuICAgID8gYCR7ZW52LkFQUERBVEF9L0FTUC5ORVQvaHR0cHNgXHJcbiAgICA6IGAke2Vudi5IT01FfS8uYXNwbmV0L2h0dHBzYDtcclxuXHJcbmNvbnN0IGNlcnRpZmljYXRlTmFtZSA9IFwiY2xpbWF0ZWNvZGV4LmNsaWVudFwiO1xyXG5jb25zdCBjZXJ0RmlsZVBhdGggPSBwYXRoLmpvaW4oYmFzZUZvbGRlciwgYCR7Y2VydGlmaWNhdGVOYW1lfS5wZW1gKTtcclxuY29uc3Qga2V5RmlsZVBhdGggPSBwYXRoLmpvaW4oYmFzZUZvbGRlciwgYCR7Y2VydGlmaWNhdGVOYW1lfS5rZXlgKTtcclxuXHJcbmlmICghZnMuZXhpc3RzU3luYyhjZXJ0RmlsZVBhdGgpIHx8ICFmcy5leGlzdHNTeW5jKGtleUZpbGVQYXRoKSkge1xyXG4gIGlmIChcclxuICAgIDAgIT09XHJcbiAgICBjaGlsZF9wcm9jZXNzLnNwYXduU3luYyhcclxuICAgICAgXCJkb3RuZXRcIixcclxuICAgICAgW1xyXG4gICAgICAgIFwiZGV2LWNlcnRzXCIsXHJcbiAgICAgICAgXCJodHRwc1wiLFxyXG4gICAgICAgIFwiLS1leHBvcnQtcGF0aFwiLFxyXG4gICAgICAgIGNlcnRGaWxlUGF0aCxcclxuICAgICAgICBcIi0tZm9ybWF0XCIsXHJcbiAgICAgICAgXCJQZW1cIixcclxuICAgICAgICBcIi0tbm8tcGFzc3dvcmRcIixcclxuICAgICAgXSxcclxuICAgICAgeyBzdGRpbzogXCJpbmhlcml0XCIgfVxyXG4gICAgKS5zdGF0dXNcclxuICApIHtcclxuICAgIHRocm93IG5ldyBFcnJvcihcIkNvdWxkIG5vdCBjcmVhdGUgY2VydGlmaWNhdGUuXCIpO1xyXG4gIH1cclxufVxyXG5cclxuY29uc3QgdGFyZ2V0ID0gZW52LkFTUE5FVENPUkVfSFRUUFNfUE9SVFxyXG4gID8gYGh0dHBzOi8vbG9jYWxob3N0OiR7ZW52LkFTUE5FVENPUkVfSFRUUFNfUE9SVH1gXHJcbiAgOiBlbnYuQVNQTkVUQ09SRV9VUkxTXHJcbiAgPyBlbnYuQVNQTkVUQ09SRV9VUkxTLnNwbGl0KFwiO1wiKVswXVxyXG4gIDogXCJodHRwczovL2xvY2FsaG9zdDo3MDkzXCI7XHJcblxyXG4vLyBodHRwczovL3ZpdGVqcy5kZXYvY29uZmlnL1xyXG5leHBvcnQgZGVmYXVsdCBkZWZpbmVDb25maWcoe1xyXG4gIHBsdWdpbnM6IFtwbHVnaW4oKSwgc3ZncigpXSxcclxuICByZXNvbHZlOiB7XHJcbiAgICBhbGlhczoge1xyXG4gICAgICBcIkBcIjogZmlsZVVSTFRvUGF0aChuZXcgVVJMKFwiLi9zcmNcIiwgaW1wb3J0Lm1ldGEudXJsKSksXHJcbiAgICB9LFxyXG4gIH0sXHJcbiAgc2VydmVyOiB7XHJcbiAgICBwcm94eToge1xyXG4gICAgICBcIl4vd2VhdGhlcmZvcmVjYXN0XCI6IHtcclxuICAgICAgICB0YXJnZXQsXHJcbiAgICAgICAgc2VjdXJlOiBmYWxzZSxcclxuICAgICAgfSxcclxuICAgIH0sXHJcbiAgICBwb3J0OiA1MTczLFxyXG4gICAgaHR0cHM6IHtcclxuICAgICAga2V5OiBmcy5yZWFkRmlsZVN5bmMoa2V5RmlsZVBhdGgpLFxyXG4gICAgICBjZXJ0OiBmcy5yZWFkRmlsZVN5bmMoY2VydEZpbGVQYXRoKSxcclxuICAgIH0sXHJcbiAgfSxcclxuICBjc3M6IHtcclxuICAgIHByZXByb2Nlc3Nvck9wdGlvbnM6IHtcclxuICAgICAgc2Nzczoge1xyXG4gICAgICAgIGFkZGl0aW9uYWxEYXRhOiBgXHJcbiAgICAgICAgICBAaW1wb3J0IFwic3JjL3N0eWxlcy9jb2xvcnMuc2Nzc1wiO1xyXG4gICAgICAgICAgQGltcG9ydCBcInNyYy9zdHlsZXMvbWVkaWEuc2Nzc1wiO1xyXG4gICAgICAgICAgYCxcclxuICAgICAgfSxcclxuICAgIH0sXHJcbiAgfSxcclxufSk7XHJcbiJdLAogICJtYXBwaW5ncyI6ICI7QUFBaVgsU0FBUyxlQUFlLFdBQVc7QUFFcFosU0FBUyxvQkFBb0I7QUFDN0IsT0FBTyxZQUFZO0FBQ25CLE9BQU8sUUFBUTtBQUNmLE9BQU8sVUFBVTtBQUNqQixPQUFPLG1CQUFtQjtBQUMxQixTQUFTLFdBQVc7QUFDcEIsT0FBTyxVQUFVO0FBUjBOLElBQU0sMkNBQTJDO0FBUzVSLElBQU0sYUFDSixJQUFJLFlBQVksVUFBYSxJQUFJLFlBQVksS0FDekMsR0FBRyxJQUFJLE9BQU8sbUJBQ2QsR0FBRyxJQUFJLElBQUk7QUFFakIsSUFBTSxrQkFBa0I7QUFDeEIsSUFBTSxlQUFlLEtBQUssS0FBSyxZQUFZLEdBQUcsZUFBZSxNQUFNO0FBQ25FLElBQU0sY0FBYyxLQUFLLEtBQUssWUFBWSxHQUFHLGVBQWUsTUFBTTtBQUVsRSxJQUFJLENBQUMsR0FBRyxXQUFXLFlBQVksS0FBSyxDQUFDLEdBQUcsV0FBVyxXQUFXLEdBQUc7QUFDL0QsTUFDRSxNQUNBLGNBQWM7QUFBQSxJQUNaO0FBQUEsSUFDQTtBQUFBLE1BQ0U7QUFBQSxNQUNBO0FBQUEsTUFDQTtBQUFBLE1BQ0E7QUFBQSxNQUNBO0FBQUEsTUFDQTtBQUFBLE1BQ0E7QUFBQSxJQUNGO0FBQUEsSUFDQSxFQUFFLE9BQU8sVUFBVTtBQUFBLEVBQ3JCLEVBQUUsUUFDRjtBQUNBLFVBQU0sSUFBSSxNQUFNLCtCQUErQjtBQUFBLEVBQ2pEO0FBQ0Y7QUFFQSxJQUFNLFNBQVMsSUFBSSx3QkFDZixxQkFBcUIsSUFBSSxxQkFBcUIsS0FDOUMsSUFBSSxrQkFDSixJQUFJLGdCQUFnQixNQUFNLEdBQUcsRUFBRSxDQUFDLElBQ2hDO0FBR0osSUFBTyxzQkFBUSxhQUFhO0FBQUEsRUFDMUIsU0FBUyxDQUFDLE9BQU8sR0FBRyxLQUFLLENBQUM7QUFBQSxFQUMxQixTQUFTO0FBQUEsSUFDUCxPQUFPO0FBQUEsTUFDTCxLQUFLLGNBQWMsSUFBSSxJQUFJLFNBQVMsd0NBQWUsQ0FBQztBQUFBLElBQ3REO0FBQUEsRUFDRjtBQUFBLEVBQ0EsUUFBUTtBQUFBLElBQ04sT0FBTztBQUFBLE1BQ0wscUJBQXFCO0FBQUEsUUFDbkI7QUFBQSxRQUNBLFFBQVE7QUFBQSxNQUNWO0FBQUEsSUFDRjtBQUFBLElBQ0EsTUFBTTtBQUFBLElBQ04sT0FBTztBQUFBLE1BQ0wsS0FBSyxHQUFHLGFBQWEsV0FBVztBQUFBLE1BQ2hDLE1BQU0sR0FBRyxhQUFhLFlBQVk7QUFBQSxJQUNwQztBQUFBLEVBQ0Y7QUFBQSxFQUNBLEtBQUs7QUFBQSxJQUNILHFCQUFxQjtBQUFBLE1BQ25CLE1BQU07QUFBQSxRQUNKLGdCQUFnQjtBQUFBO0FBQUE7QUFBQTtBQUFBLE1BSWxCO0FBQUEsSUFDRjtBQUFBLEVBQ0Y7QUFDRixDQUFDOyIsCiAgIm5hbWVzIjogW10KfQo=
