module.exports = {
  purge: {
    enabled: true,
    content: ["./Views/**/*.cshtml"],
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [
    require("@tailwindcss/forms"),
    require('@tailwindcss/typography')
  ],
};
