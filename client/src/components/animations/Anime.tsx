import React, { useEffect, useRef } from "react";
import anime from "animejs";
import { AnimeInstance } from "animejs";

interface AnimeProps {
  init: AnimeInstance | AnimeInstance[];
}

const Anime: React.FC<AnimeProps> = ({ init, ...props }) => {
  const thisRef = useRef(null);
  const animationRef = useRef(null);

  useEffect(() => {
    if (Array.isArray(init)) {
      animationRef.current = init.map((animes) =>
        anime({ targets: thisRef.current, ...animes })
      );
    } else {
      animationRef.current = anime({ targets: thisRef.current, ...init });
    }
  }, []);

  return (
    <div ref={thisRef} {...props}>
      {props.children}
    </div>
  );
};

export default Anime;
