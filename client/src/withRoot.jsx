import { CssBaseline } from "@material-ui/core";
import { createMuiTheme } from "@material-ui/core/styles";
import { ThemeProvider } from "@material-ui/styles";
import * as React from "react";

const theme = createMuiTheme({
  palette: {
    primary: {
      main: "#FC7753",
      // contrastText: "#fff",
    },
    secondary: {
      main: "#403D56",
      contrastText: "#fff",
    },
  },
  typography: {
    h1: {
      fontSize: "2rem",
      fontWeight: 700,
    },
    h2: {
      fontSize: "2rem",
      fontWeight: 500,
    },
    h3: {
      fontSize: "1.5rem",
      fontWeight: 500,
    },
    h4: {
      fontSize: "1.25rem",
      fontWeight: 500,
    },
    h5: {
      fontSize: "1rem",
      fontWeight: 500,
    },
    subtitle1: {
      lineHeight: "inherit",
    },
    button: {
      textTransform: "none",
    },
  },
  overrides: {
    MuiCssBaseline: {
      "@global": {
        li: {
          listStyle: "none",
        },
        img: {
          maxWidth: "100%",
          display: "block",
        },
      },
    },
  },
});

if (process.env.NODE_ENV === "development") console.info("[Theme]:", theme);

export const wrapRootElement = ({ element }) => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      {element}
    </ThemeProvider>
  );
};
