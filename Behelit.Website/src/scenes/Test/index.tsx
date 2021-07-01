import { Stage, Sprite, Container, useTick } from '@inlet/react-pixi';
import { useState } from 'react';
import Field from './components/Field';

const Test = () => {
  let i = 0;

  const Bunny = () => {
    // states
    const [x, setX] = useState(0);
    const [y, setY] = useState(0);
    const [rotation, setRotation] = useState(0);

    // custom ticker
    useTick((delta) => {
      i += 0.05 * delta;

      setX(Math.sin(i) * 100);
      setY(Math.sin(i / 1.5) * 100);
      setRotation(-10 + Math.sin(i / 10 + Math.PI * 2) * 10);
    });

    return (
      <Sprite
        image="https://s3-us-west-2.amazonaws.com/s.cdpn.io/693612/IaUrttj.png"
        anchor={0.5}
        x={x}
        y={y}
        rotation={rotation}
      />
    );
  };

  return (
    <Stage width={window.innerWidth} height={window.innerHeight} options={{ autoDensity: true, backgroundAlpha: 0 }}>
      <Container x={0} y={0}>
        <Field height={window.innerHeight} />
      </Container>
      <Container x={150} y={150}>
        <Bunny />
      </Container>
    </Stage>
  );
};

export default Test;
