// https://nuxt.com/docs/api/configuration/nuxt-config
import tailwindcss from "@tailwindcss/vite";
export default defineNuxtConfig({
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },

  vite: {
   plugins: [tailwindcss() as any],
 },

  css: ['~/assets/css/main.css'],
  modules: ['@nuxt/icon', '@nuxt/image'],
  icon: {
    
    size: '34px', // default <Icon> size applied
    class: 'icon', // default <Icon> class applied
    mode: 'css', // default <Icon> mode applied
    aliases: {
      'nuxt': 'logos:nuxt-icon',
    },
    cssLayer: 'base' // set the css layer to inject to
  }
})