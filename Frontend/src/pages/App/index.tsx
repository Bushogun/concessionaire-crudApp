import { Layout } from '../../components/Layout';
import { Providers } from '../../redux/provider';
import { ReactNode } from 'react';

type Props = {
  children?: ReactNode
}

const App = (props: Props) => {
  return (
    <>
      <Providers>
        <Layout />
      </Providers>
    </>
  )
}

export default App
