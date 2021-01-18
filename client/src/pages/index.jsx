import { Box } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import React from "react";
import classNames from "classnames";

import Game from "../components/Game";
import ParticleBackground from "../components/animations/ParticleBackground";

const HomePage = ({ ...props }) => {
  const classes = useStyles(props);

  return (
    <div className={classNames(classes.root, props.className)}>
      <ParticleBackground />
      <Game />
    </div>
  );
};

const useStyles = makeStyles((theme) => ({
  root: {
    height: "100vh",
    width: "100vw",
    background: "radial-gradient(#021027, #000000);",
    color: "white",
  },
}));

export default HomePage;
