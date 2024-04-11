pipeline {
  agent any

  stages {
    stage('Build') {
      steps {
        sh 'docker build -t minimal-api-hello-world .'
        sh 'docker tag minimal-api-hello-world $DOCKER_BDOTNET_IMAGE'
      }
    }
    stage('Test') {
      steps {
        sh 'docker run minimal-api-hello-world dotnet test app/Tests/'
      }
    }
    stage('Deploy') {
      steps {
        withCredentials([usernamePassword(credentialsId: "${DOCKER_REGISTRY_CREDS}", passwordVariable: 'DOCKER_PASSWORD', usernameVariable: 'DOCKER_USERNAME')]) {
          sh "echo \$DOCKER_PASSWORD | docker login -u \$DOCKER_USERNAME --password-stdin docker.io"
          sh 'docker push $DOCKER_BDOTNET_IMAGE'
        }
      }
    }
  }
  post {
    always {
      sh 'docker logout'
    }
  }
}