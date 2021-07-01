import { Sprite } from '@inlet/react-pixi';

interface Props {
  height: number;
}

const Field = ({ height }: Props) => <Sprite image="assets/field.png" x={0} y={0} height={height} />;

export default Field;
