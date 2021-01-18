module.exports = {
  siteMetadata: {
    title: "Investi Game",
    description: "Learn Investment",
    author: "Segmentation Fault",
    siteUrl: "https://investi.space"
  },
  plugins: [
    "gatsby-plugin-sharp",
    "gatsby-plugin-react-helmet",
    "gatsby-plugin-sitemap",
    "gatsby-plugin-offline",
    "gatsby-transformer-sharp",
    {
      resolve: `gatsby-plugin-material-ui`,
      options: {
        stylesProvider: {
          injectFirst: true,
        },
      },
    },
    {
      resolve: "gatsby-source-filesystem",
      options: {
        name: "pages",
        path: "./src/pages",
      },
      __key: "pages",
    },
  ],
};
