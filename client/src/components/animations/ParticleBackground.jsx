import React from "react";
import { makeStyles } from "@material-ui/styles";
import Anime from "./Anime";

/**
 * Inspiration from https://codepen.io/tonkotsuboy/pen/xaMVpo
 */
const ParticleBackground = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      {particleProperties.map((props, i) => (
        <Anime
          init={particleMovementAnimes[i]}
          className={classes.particleWrapper}
          style={props}
          key={`particle-wrapper-${i}`}
        >
          <Anime init={[...particleAnimes[i]]} className={classes.particle} />
        </Anime>
      ))}
    </div>
  );
};

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    height: "100%",
  },
  particleWrapper: {
    position: "absolute",
    transform: "translateY(-10vh)",
  },
  particle: {
    width: "100%",
    height: "100%",
    borderRadius: "50%",
    mixBlendMode: "screen",
    backgroundImage: `radial-gradient(
      hsl(180, 100%, 80%),
      hsl(180, 100%, 80%) 10%,
      hsla(180, 100%, 80%, 0) 56%
    );`,
  },
}));

const PARTICLE_COUNT = 69;

const particleProperties = [...Array(PARTICLE_COUNT)].map((_, i) => {
  const size = Math.random() * 10 + 1;
  return {
    width: size,
    height: size,
  };
});

const particleAnimes = [...Array(PARTICLE_COUNT)].map(() => [
  {
    loop: true,
    opacity: [0.7, 1],
    duration: 250,
    easing: "linear",
    direction: "alternate",
    delay: Math.random() * 4000,
  },
  {
    loop: true,
    scaleX: [0.4, 2.2],
    scaleY: [0.4, 2.2],
    duration: 1000,
    easing: "linear",
    direction: "alternate",
    delay: Math.random() * 4000,
  },
]);

const particleMovementAnimes = [...Array(PARTICLE_COUNT)].map(() => ({
  loop: true,
  delay: Math.random() * 8000,
  duration: 14000 + Math.random() * 8000,
  translateX: [`${Math.random() * 100}vw`, `${Math.random() * 100}vw`],
  translateY: [
    `${Math.random() * 10 + 100}vh`,
    `${-(Math.random() * 10 + 100) - Math.random() * 30}vh`,
  ],
  translateZ: 0,
  easing: "linear",
}));

export default ParticleBackground;
