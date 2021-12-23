import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';

const FeatureList = [
  {
    title: 'Free and open source',
    description: (
      <>
        ALE is developed out in the open for all the world to see! It's free
        to use and modify, and shall remain that way. 
      </>
    ),
  },
  {
    title: 'Automatic Serialization',
    description: (
      <>
        ALE automatically serializes all the data that needs to be saved.
      </>
    ),
  },
  {
    title: 'Built for the runtime',
    description: (
      <>
        Built from the ground up to function in your built Unity game. 
      </>
    ),
  }
];

function Feature({Svg, title, description}) {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center padding-horiz--md">
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
