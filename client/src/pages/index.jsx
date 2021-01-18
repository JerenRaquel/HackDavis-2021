import React, { useEffect, useRef } from "react";
import unityProgress from "../../static/v1.0/TemplateData/UnityProgress";
import "../../static/v1.0/TemplateData/style.css";

const HomePage = ({ ...props }) => {
  const unityInstance = useRef(null);

  useEffect(() => {
    unityInstance.current = window.UnityLoader.instantiate(
      "unityContainer",
      "v1.0/Build/Builds.json",
      { onProgress: unityProgress }
    );
  }, []);

  return (
    <div className="webgl-content">
      <div id="unityContainer" style={{ width: 960, height: 600 }} />
      <div className="footer">
        <div className="webgl-logo" />
        <div
          className="fullscreen"
          onClick={() => unityInstance.current.SetFullscreen(1)}
        />
        <div className="title">Stonks by Segmentation Fault</div>
      </div>
    </div>
  );
};

export default HomePage;
