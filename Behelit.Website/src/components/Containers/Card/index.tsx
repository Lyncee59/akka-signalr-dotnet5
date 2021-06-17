import { ReactNode } from 'react';
import styled from 'styled-components';

const Wrapper = styled.div`
  padding: 1rem;
  background: ${(props) => props.theme.colors.primary};
  border: 1px solid ${(props) => props.theme.colors.tertiary};
`;

interface Props {
  children: ReactNode;
}

const Card = ({ children }: Props) => <Wrapper>{children}</Wrapper>;

export default Card;
