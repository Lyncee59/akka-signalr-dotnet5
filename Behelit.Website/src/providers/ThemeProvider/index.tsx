import { ReactNode } from 'react';
import { ThemeProvider } from 'styled-components';
import defaultTheme from './theme';

interface Props {
  children: ReactNode;
}

const CustomThemeProvider = ({ children }: Props) => <ThemeProvider theme={defaultTheme}>{children}</ThemeProvider>;

export default CustomThemeProvider;
